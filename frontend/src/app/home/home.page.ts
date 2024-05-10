import {Component} from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {DataService} from "../data.service";
import {firstValueFrom} from "rxjs";
import {Task} from "../models";
import {ModalController, ToastController} from "@ionic/angular";
import {CreateTaskComponent} from "../createTask/create-task.component";

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(public http: HttpClient, public modalController: ModalController, public toastController: ToastController, public dataService: DataService) {
    this.getTasks();
  }

  async getTasks() {
    const call = this.http.get<Task[]>('http://5.189.170.247:5002/api/tasks');
    this.dataService.tasks = await firstValueFrom<Task[]>(call);
  }

  async deleteTask(taskId: number | undefined) {
    try {
      await firstValueFrom(this.http.delete<Task>('http://5.189.170.247:5002/api/tasks/' + taskId))
      this.dataService.tasks = this.dataService.tasks.filter(a => a.taskId != taskId)

      const toast = await this.toastController.create({
        message: 'Task deleted successfully.',
        duration: 1200,
        color: 'success'
      })
      toast.present();
    } catch (error: any) {

      let errorMessage = 'Error';

      if (error instanceof HttpErrorResponse) {

        errorMessage = error.error?.message || 'Server error';
      } else if (error.error instanceof ErrorEvent) {

        errorMessage = error.error.message;
      }

      const toast = await this.toastController.create({
        color: 'danger',
        duration: 2000,
        message: errorMessage
      });

      toast.present();
    }
  }

  async createTask() {
    const modal = await this.modalController.create({
      component: CreateTaskComponent
    });
    modal.present();
  }
}
