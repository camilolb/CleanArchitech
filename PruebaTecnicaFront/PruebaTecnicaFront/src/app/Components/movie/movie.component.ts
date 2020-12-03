import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import {ActorService} from '../../services/actor.service';
import {CountryService} from '../../services/country.service';
import {MovieService} from '../../services/movie.service';
import {GenderService} from '../../services/gender.service';


@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  actors: Array<any> = []; 
  countrys: Array<any> = []; 
  movies: Array<any> = [];
  genders: Array<any> = [];  
  selectInit = -1;
  formGroup;

  movie = {
    Name: Number,
    GenderId: Number,
    CountryId: Number,
    ActorId: Number,
    DirectorId: Number,
    Description: String
  }

  constructor(
    private formBuilder: FormBuilder,
    private actorService: ActorService,
    private countryService: CountryService,
    private movieService: MovieService,
    private genderService: GenderService
  ) {
    this.formGroup = this.formBuilder.group({
      Title: '',
      Description: '',
      CountryId:  [0, Validators.required],
      GenderId: 0,
      ActorId: 0,
      DirectorId: 0
    });
   }

  ngOnInit(): void {
    this.getMovies();
    this.getFeatures();
  }

  getFeatures() {
    this.getActors();
    this.getCountrys();
    this.getGenders();
  }

  getMovies() {
    return this.movieService.getMovies().subscribe((res : any) => {
      console.log(res);
      this.movies = res.data;
    });
  }

  deleteMovie(id: number){
    return this.movieService.deleteMovie(id).subscribe((res : any) => {
      if(res.data){
        alert("eliminado exitosamente");
        this.getMovies();
      }else{
        alert("Error interno del servidor");
      }
      
      console.log(res);
      
    });
  }

  getActors() {
    return this.actorService.getActors().subscribe((res : any) => {
      this.actors = res.data;
    });
  }

  getCountrys() {
    return this.countryService.getCountrys().subscribe((res : any) => {
      this.countrys = res.data;
    });
  }

  postMovie(formData: any){

    if(this.validateField(formData)){
      this.movieService.postMovie(formData).toPromise().then(data => {
        this.getMovies();
        alert("Película guardada exitosamente");

      })
    }
  }

  validateField(data: any){
    if(data.ActorId > 0
      && data.CountryId > 0
      && data.GenderId > 0
      && data.Title != "")
      {
        return true;
      }else{
        alert("Complete los campos obligatorios");
      }
      return false;
  }

  getGenders() {
    return this.genderService.getGenders().subscribe((res : any) => {
      this.genders = res.data;
      
    });
  }


}
