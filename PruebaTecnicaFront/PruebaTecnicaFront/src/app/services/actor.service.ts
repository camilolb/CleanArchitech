import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class ActorService {

  header = new HttpHeaders();

  constructor(private http: HttpClient) { 
    this.header = this.header.append('content-type', 'application/json');
  }

  getActors(){
    return this.http.get(environment.apiUrl + '/Actor', {headers : this.header});
  }  

  getActor(id: number)
  {
    return this.http.get(environment.apiUrl + '/Actor?id=' + id, {headers: this.header})
  }

  deleteActor(id: number){
    return this.http.delete(environment.apiUrl + '/Actor/' + id, {headers: this.header})
  }

  postActor(data: any){
    return this.http.post(environment.apiUrl + '/Actor', data, {headers: this.header})
  }
}
