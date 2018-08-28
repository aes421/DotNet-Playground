import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { CreateService } from '../create.service';

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

    constructor(private createService : CreateService) {
        this.createService.getStatuses().subscribe(
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
        this.createService.postTask(this.task.value, this.selectedStatus).subscribe();
  }
}
