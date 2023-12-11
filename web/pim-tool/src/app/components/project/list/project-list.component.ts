import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogActions, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Router, RouterLink } from '@angular/router';
import { Project } from '../../../models/project';
import { ProjectService } from '../../../services/project.service';
import { DeleteDialogComponent } from '../../common/dialog/delete-alert-dialog.component';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule,
    MatIconModule, MatButtonModule, MatDialogModule, MatDialogActions, MatPaginatorModule, MatTableModule, RouterLink],
  templateUrl: './project-list.component.html',
  styleUrl: './project-list.component.css'
})
export class ProjectListComponent implements OnInit{
  projects: Project[] = [];
  globalFilter?: string;
  status?: string;
  dataSource!: MatTableDataSource<Project>;
  displayedColumns = ['projectNumber', 'name', 'status', 'customer', 'startDate', 'delete', 'edit']
  @ViewChild(MatPaginator) paginator: MatPaginator = new MatPaginator(new MatPaginatorIntl, ChangeDetectorRef.prototype);
  constructor(private projectService: ProjectService, private dialog: MatDialog, private router: Router){  }

  ngOnInit(): void {
    this.fetch();
  }

  fetch(): void{
    this.projectService.getProjects(this.globalFilter, this.status).subscribe((data: Project[]) => {
      this.projects = data;
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
    });
  }

  delete(id: number){
    let dialogRef = this.dialog.open(DeleteDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      // NOTE: The result can also be nothing if the user presses the `esc` key or clicks outside the dialog
      if (result == 'confirm') {
        this.projectService.delete(id);
        this.reload();
      }
    })
  }

  reload(){
    window.location.reload();
  }

  edit(id: number){
    this.router.navigate([`/edit-project/${id}`]);
  }
}
