import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { MatChipsModule } from "@angular/material/chips";
import { MatDialog } from "@angular/material/dialog";
import { MatIconModule } from "@angular/material/icon";
import { MatSelectModule } from "@angular/material/select";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { Employee } from "../../../models/employee";
import { Group } from "../../../models/group";
import { EmployeeService } from "../../../services/employee.service";
import { GroupService } from "../../../services/group.service";
import { ProjectService } from "../../../services/project.service";
import { InformDialogComponent } from "../../common/dialog/informDialog/inform-dialog.component";

@Component({
    selector: 'project-creation',
    standalone: true,
    templateUrl: './project-creation.component.html',
    imports: [ReactiveFormsModule, CommonModule, MatSelectModule, MatChipsModule, MatIconModule, RouterLink]
})
export class ProjectCreation implements OnInit{
    employees: Employee[] = [];
    groups: Group[] = [];
    isEdit: boolean = false;
    id!: number;
    project: FormGroup = new FormGroup({
        projectNumber: new FormControl([],Validators.required),
        name: new FormControl([], [Validators.required, Validators.maxLength(50)]),
        customer: new FormControl([],[Validators.required, Validators.maxLength(50)]),
        groupId: new FormControl([],Validators.required),
        members: new FormControl([],Validators.required),
        status: new FormControl([],Validators.required),
        startDate: new FormControl([],Validators.required),
        endDate: new FormControl()
    });
    constructor(
        private route: ActivatedRoute,
        private projectService: ProjectService, private employeeService: EmployeeService, private groupService: GroupService,
        private dialog: MatDialog, private router: Router){
            if(route.snapshot.params['id'] != null){
                this.id = Number(route.snapshot.params['id']);
                this.isEdit = true;
                this.project.controls['projectNumber'].disable();
            } else{
                this.project.controls['status'].disable();
                this.project.controls['status'].setValue('NEW');
                this.project.controls['status'];
            }
        }
    ngOnInit(): void {
        this.fetchEmployees();
        this.fetchGroups();
        if(this.isEdit){
            this.fetchProject();
        }
    }

    onSubmit(){
        if(!this.project.valid){
            return;
        }
        if(this.isEdit){
            this.projectService.updateProject(this.id, this.project.getRawValue());
        } else{
            const result = this.projectService.createProject(this.project.getRawValue());
            if(result){
                let dialogRef = this.dialog.open(InformDialogComponent);
                dialogRef.afterClosed().subscribe(result => {
                    this.router.navigate(['/projects']);
                });
            }
        }
    }

    private fetchEmployees(): void{
        this.employeeService.getAll().subscribe((data: Employee[]) => {
            this.employees = data;
        });
    }

    private fetchGroups(): void{
        this.groupService.getAll().subscribe((data: Group[]) => {
            this.groups = data;
        });
    }

    private fetchProject(): void{
        this.projectService.getProject(this.id).subscribe((data) => {
            this.project.setValue({
                projectNumber: data.projectNumber,
                name: data.name,
                customer: data.customer,
                groupId: data.groupId,
                members: data.members ? data.members : '',
                status: data.status,
                startDate: data.startDate,
                endDate: data.endDate
            });
        });
    }

    // private getProjectStatuses(): void{
    //     const projectStatusEnum = ProjectStatus;
    //     const keys: string[] = Object.keys(ProjectStatus);
    //     keys.forEach(k => {
    //         this.statuses.push({key: k, value: projectStatusEnum[k as any]})
    //         //this.statuses.set();
    //     });
    // }
}