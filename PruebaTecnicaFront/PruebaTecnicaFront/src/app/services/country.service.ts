import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})

export class CountryService {

  header = new HttpHeaders();

  constructor(private http: HttpClient) { 
    this.header = this.header.append('content-type', 'application/json');
  }

  getCountrys(){
    return this.http.get(environment.apiUrl + '/Country', {headers : this.header});
  }  

  getCountry(id: number) {
    return this.http.get(environment.apiUrl + '/Country?id=' + id, {headers: this.header})
  }

  postCountry(data: any){
    return this.http.post(environment.apiUrl + '/Country', data, {headers: this.header})
  }
  deleteCountry(id: number){
    return this.http.delete(environment.apiUrl + '/Country/' + id, {headers: this.header})
  }

}
