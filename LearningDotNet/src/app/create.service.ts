import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CreateService {

  constructor(private http: HttpClient) { }

  getStatuses(): Observable<any> {
    return this.http.get("/Tasks/GetStatuses");
  }

  postTask(name: string, statusId: number): Observable<any> {
    return this.http.post('/Tasks/Create', { Name: name, StatusId: statusId })
  }
}
