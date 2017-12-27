import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import { catchError, map, tap } from 'rxjs/operators';
import {of} from "rxjs/observable/of";
import { retry } from 'rxjs/operators/retry';
import {User} from "../../sharded/models/User";
import {Project} from "../../sharded/models/Proj";
import {Task} from "../../sharded/models/Task";

const
    httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
    };

const taskUrl = "http://localhost:5000/task"
const apiUrl = "http://localhost:5000"


@Injectable()
export class TasksService {

  constructor(private http: HttpClient) { }

  createTask(task: Task): Observable<any> {
      return this.http.post(taskUrl, task, httpOptions)
  }

  editTask(task: Task): Observable<any> {
      console.log("Edit task completed")
    return this.http.put(taskUrl+'/'+task.id, task, httpOptions)
  }

}
