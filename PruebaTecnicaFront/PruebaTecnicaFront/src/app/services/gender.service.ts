import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http'


@Injectable({
  providedIn: 'root'
})
export class GenderService {

  header = new HttpHeaders();

  constructor(private http: HttpClient) { 
    this.header = this.header.append('content-type', 'application/json');
  }

  getGenders(){
    return this.http.get(environment.apiUrl + '/Gender', {headers : this.header});
  }  

  getGender(id: number) {
    return this.http.get(environment.apiUrl + '/Gender?id=' + id, {headers: this.header})
  }

  postGender(data: any){
    return this.http.post(environment.apiUrl + '/Gender', data, {headers: this.header})
  }

  deleteGender(id: number){
    return this.http.delete(environment.apiUrl + '/Gender/' + id, {headers: this.header})
  }


}
