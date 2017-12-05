import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import { catchError, map, tap } from 'rxjs/operators';
import {of} from "rxjs/observable/of";
import { retry } from 'rxjs/operators/retry';
import {User} from "../../users/models/User";
import {Project} from "../models/Proj";


const
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

const projectsUlr = "porjects"


@Injectable()
export class ProjectsService {

  constructor(private http: HttpClient) {
  }

  getProjects(): Observable<Project[]>{
    return of(PROJECTS)
  }

  getProject(id: number): Observable<Project> {

    return of(PROJECTS.find(x => x.id == id))
  }
}

export const PROJECTS: Project[] = [
  { id: 11, name: 'Osobiste', tasks: [
      { id: 1, name: "Kupić mleko"},
      { id: 2, name: "Iść do fryzjera"},
      { id: 3, name: "Zadzwonić do domu"},
    ]
  },
  { id: 12, name: 'Studia', tasks: [
      { id: 4, name: "Zrobić projekt"},
      { id: 5, name: "Kolos"},
      { id: 6, name: "Egzamin"},
    ]
  }
];


