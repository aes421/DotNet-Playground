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

    selectedStatus: number;
    statuses: Array<{Id: number, Description: string}>;

    constructor(private http: HttpClient) {
      this.http.get("/Home/GetStatuses").subscribe(
          (data: Array<{ Id: number, Description: string }>) => {
              this.statuses = data;
              this.selectedStatus = this.statuses[0].Id;
          });
    }

    public selectStatus(value: any) {
        console.log(value);
        this.selectedStatus = value;
    }

    public onSave(): void {
        console.log(this.selectedStatus);
        console.log(this.statuses[this.selectedStatus]);
        console.log(this.statuses[this.selectedStatus].Description);
        this.http.post('/Home/CreateEdit', { task: { TaskName: this.task.value, Status: { Id: this.selectedStatus, Description: this.statuses[this.selectedStatus].Description } } }).subscribe();
  }
}
