import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { $ } from 'protractor';
import {ActorService} from '../../../services/actor.service';
import {CountryService} from '../../../services/country.service';


@Component({
  selector: 'app-actor',
  templateUrl: './actor.component.html',
  styleUrls: ['./actor.component.css']
})

export class ActorComponent implements OnInit {

  actors: Array<any> = []; 
  countrys: Array<any> = []; 
  disabledModal: boolean = false;
  formGroup;

  actor = {
    ActorId: Number,
    Name: String,
    LastName: String,
    CountryId: Number,
    Date: String
  }


  constructor(
    private formBuilder: FormBuilder,
    private actorService: ActorService,
    private countryService: CountryService
    )
    { 
      this.formGroup = this.formBuilder.group({
        Name: '',
        LastName: '',
        CountryId: 0
      });
    }

  ngOnInit(): void {
    this.getActors();
    this.getCountrys();
  }

  getActors() {
    return this.actorService.getActors().subscribe((res : any) => {
      this.actors = res.data;
      console.log(this.actors);
    });
  }

  getActor(id: number){
    return this.actorService.getActor(id).toPromise().then((data: any) => {
      this.actor = data;
    })
  }

  deleteActor(id: number){
    return this.actorService.deleteActor(id).subscribe((res : any) => {
      if(res.data){
        alert("eliminado exitosamente");
        this.getActors();
      }else{
        alert("Error interno del servidor");
      }      
    });
  }

  postActor(formData: any){ 
    let validateField = this.validateField(formData);
    
    if(validateField){

        this.actorService.postActor(formData).toPromise().then(data => {
          alert("Guardado Correctamente");
          this.getActors();
          console.log(data);
        })
    }

  }

  validateField(data: any){
    if(data.Name != ""
    && data.LastName != ""){
      return true;
    }
    alert("Completa los campos obligatorios");
    return false;
  }

  getCountrys() {
    return this.countryService.getCountrys().subscribe((res : any) => {
      this.countrys = res.data;
      console.log(res.data);
    });
  }



}
