import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CreateService {

  constructor(private http: HttpClient) { }

  getStatuses(): Observable<any> {
    return this.http.get("/CreateEdit/GetStatuses");
  }

  postTask(name: string, statusId: number): Observable<any> {
    return this.http.post('/CreateEdit/CreateEdit', { Name: name, Id: statusId })
  }
}
