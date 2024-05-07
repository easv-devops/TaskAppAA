import {Injectable} from "@angular/core";
import {Task} from "./models";

@Injectable({
  providedIn: 'root'
})

export class DataService {
  public tasks: Task[] = [];
}
