import { Component, OnInit } from '@angular/core';
import {CountryService} from '../../services/country.service'
import { FormBuilder } from '@angular/forms';


interface Country{
  CountryId: number;
  Name: string;
  Date: string;
}

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {

  countrys: Array<any> = []; 
  formGroup;

  country = {
    CountryId: Number,
    Name: String,
    Date: String
  }

  constructor(
    private countryService: CountryService,
    private formBuilder: FormBuilder
  ) { 

    this.formGroup = this.formBuilder.group({
      Name: ''
    });
  }

  ngOnInit(): void {
    this.getCountrys();
  }

  getCountrys() {
    return this.countryService.getCountrys().subscribe((res : any) => {
      this.countrys = res.data;
    });
  }

  deleteCountry(id: number){
    return this.countryService.deleteCountry(id).subscribe((res : any) => {
      if(res.data){
        alert("eliminado exitosamente");
        this.getCountrys();
      }else{
        alert("Error interno del servidor");
      }
      
      console.log(res);
      
    });
  }

  getCountry(id: number){
    return this.countryService.getCountry(id).toPromise().then((data: any) => {
      this.country = data.data;
    })
  }

  postCountry(formData: any){ 

    let validate = this.validateField(formData);

    if(validate){
        this.countryService.postCountry(formData).toPromise().then(data => {
          alert("Se ha creado el país correctamente");
          this.getCountrys();
        })
    }

  }

  validateField(data: any){

    if(data.Name != ""){
      return true;
    }

    alert("Completa los campos obligatorios");
    return false;
  }
}
