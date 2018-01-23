import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import { catchError, map, tap } from 'rxjs/operators';
import {of} from "rxjs/observable/of";
import { retry } from 'rxjs/operators/retry';
import {User} from "../../sharded/models/User";
import {Project} from "../../sharded/models/Proj";


const
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

const projectUrl = "http://localhost:5000/project"
const apiUrl = "http://localhost:5000"

@Injectable()
export class ProjectsService {

  constructor(private http: HttpClient) {
  }

  createProject(project: Project): Observable<any> {
    return this.http.post(projectUrl, project, httpOptions)
  }

  deleteProject(project: Project): Observable<any> {
    return this.http.delete(projectUrl+'/'+project.id, httpOptions)
  }

  editProject(project: Project): Observable<any> {
    return this.http.put(projectUrl+'/'+project.id, project, httpOptions)
  }

  getProjects(): Observable<Project[]>{
    return this.http.get<Project[]>(projectUrl)
  }

  getProject(id: number): Observable<Project[]> {
      return this.http.get<Project[]>(projectUrl+"/"+id)
  }
}



