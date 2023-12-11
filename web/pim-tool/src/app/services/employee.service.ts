import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeeBaseUrl = 'https://localhost:7099/api/v1/employees';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.employeeBaseUrl);
  }
}