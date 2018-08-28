import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-to-do-form',
  templateUrl: './to-do-form.component.html',
  styleUrls: ['./to-do-form.component.css']
})
export class ToDoFormComponent {

  task = new FormControl('');
  status = new FormControl('');

  constructor(private http: HttpClient) {
  }

  public onSave(): void {
    this.http.get("/Home/GetStatuses").subscribe(
      (data: string) => {
        console.log(data);
      });
  }
}
