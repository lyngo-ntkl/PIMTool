import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectStatus } from '../models/enum/project-status';
import { Project } from '../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private projectBaseUrl = 'https://localhost:7099/api/v1/projects';
  constructor(private http: HttpClient) { }
  getProjects(globalFilter?: string, status?: string): Observable<Project[]> {
    let url = this.projectBaseUrl;
    let query = "";
    if(globalFilter != null && globalFilter.length > 0 && status != null && status.length > 0){
      query += `GlobalFilter=${globalFilter}&Status=${status}`;
    } else if(globalFilter != null && globalFilter.length > 0){
      query += `GlobalFilter=${globalFilter}`;
    } else if(status != null && status.length > 0){
      const statuses = Object.keys(ProjectStatus);
      if(statuses.includes(status)){
        query += `Status=${status}`;
      }
    }
    if(query.length > 0){
      url += `?${query}`;
    }
    return this.http.get<Project[]>(url);
  }

  getProject(id: number): Observable<Project>{
    return this.http.get<Project>(`${this.projectBaseUrl}/${id}`);
  }

  createProject(project: any): boolean{
    let result = true;
    try{
      this.http.post<HttpResponse<any>>(this.projectBaseUrl, project).subscribe(response => {
        if(response != null && response.status <200 && response.status >=300){
          result = false;
        }
      });
    } catch(e){
      console.log(e);
    }
    return result;
  }

  updateProject(id: number, project: any): boolean{
    let result = false;
    try{
      this.http.put<HttpResponse<any>>(`${this.projectBaseUrl}/${id}`, project).subscribe(response => {
        if(response.status >=200 && response.status <300){
          result = true;
        }
      });
    } catch(e){
      console.log(e);
    }
    return result;
  }

  delete(id: number){
    let response;
    try{
      this.http.delete(`${this.projectBaseUrl}/${id}`).subscribe((data: Object) => {
        response = data;
      });
    } catch(e){
      console.log(e);
    }
  }
}
