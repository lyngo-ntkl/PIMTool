import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Group } from '../models/group';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private groupBaseUrl = 'https://localhost:7099/api/v1/groups';
  constructor(private http: HttpClient) { }

  getAll(): Observable<Group[]>{
    return this.http.get<Group[]>(this.groupBaseUrl);
  }
}
