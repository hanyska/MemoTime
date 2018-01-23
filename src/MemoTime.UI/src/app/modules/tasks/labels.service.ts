import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import { catchError, map, tap } from 'rxjs/operators';
import {of} from "rxjs/observable/of";
import { retry } from 'rxjs/operators/retry';
import {User} from "../../sharded/models/User";
import {Project} from "../../sharded/models/Proj";
import {Label} from "../../sharded/models/Label";


const
    httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
    };

const labelUrl = "http://localhost:5000/label"
const apiUrl = "http://localhost:5000"

@Injectable()
export class LabelsService {
    constructor(private http: HttpClient) {}

    createLabel(label: Label): Observable<any> {
        return this.http.post(labelUrl, label, httpOptions);
    }

    getLabel(id: number): Observable<Label> {
        return this.http.get<Label>(labelUrl + "/" +id);
    }

    browseLabels(): Observable<Label[]> {
        return this.http.get<Label[]>(labelUrl);
    }
}