import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Person } from '../models/person';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { map } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseUrl:string= environment.apiUrl;
  constructor(private httpSer:HttpClient, private router:Router) { }

  addPerson( personModel:any){
    return this.httpSer.post(this.baseUrl+"persons", personModel);
  }

  getPersons(){
    return this.httpSer.get<Person[]>(this.baseUrl+"persons");
  }
}
