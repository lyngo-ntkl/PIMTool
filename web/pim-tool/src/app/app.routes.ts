import { Routes } from '@angular/router';
import { ProjectCreation } from './components/project/creation/project-creation.component';
import { ProjectListComponent } from './components/project/list/project-list.component';

export const routes: Routes = [
    {path: 'projects', component: ProjectListComponent},
    {path: 'new-project', component: ProjectCreation},
    {path: 'edit-project/:id', component: ProjectCreation}
];
