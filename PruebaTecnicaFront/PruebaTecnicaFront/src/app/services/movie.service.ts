import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http'


@Injectable({
  providedIn: 'root'
})
export class MovieService {

  header = new HttpHeaders();

    constructor(private http: HttpClient) { 
      this.header = this.header.append('content-type', 'application/json');
    }

    getMovies(){
      return this.http.get(environment.apiUrl + '/Movie', {headers : this.header});
    }  

    deleteMovie(id: number){
      
      return this.http.delete(environment.apiUrl + '/Movie/' + id, {headers: this.header})
    }
  
    getMovie(id: number)
    {
      return this.http.get(environment.apiUrl + '/Movie?id=' + id, {headers: this.header})
    }
  
    postMovie(data: any){
      return this.http.post(environment.apiUrl + '/Movie', data, {headers: this.header})
    }


}
