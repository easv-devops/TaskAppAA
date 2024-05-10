import {Component} from "@angular/core";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {firstValueFrom} from "rxjs";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {DataService} from "../data.service";
import {Task} from "../models"
import {ToastController} from "@ionic/angular";

@Component({
  selector: 'app-create-task',
  templateUrl: 'create-task.component.html',
  //styleUrls: ['home.page.scss'],
})
export class CreateTaskComponent {
  constructor(public toastController: ToastController, public dataService: DataService, public fb: FormBuilder, private http: HttpClient) {
  }

  createNewTaskForm = this.fb.group({
    taskName: ['', [Validators.required]]
  })

  async createNewTask() {
    try {
      const observable = this.http.post<Task>('http://5.189.170.247:5002/api/task', this.createNewTaskForm.getRawValue());
      const response = await firstValueFrom<Task>(observable);
      this.dataService.tasks.push(response);

      const toast = await this.toastController.create({
        message: 'Task was created!',
        duration: 1233,
        color: "success"
      })
    } catch (e) {
      if (e instanceof HttpErrorResponse) {
        const toast = await this.toastController.create({
          message: e.error.messageToClient,
          color: "danger"
        });
        toast.present();
      }
    }
  }
}
