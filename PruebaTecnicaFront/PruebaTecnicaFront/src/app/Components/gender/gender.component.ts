import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import {GenderService} from '../../services/gender.service';

@Component({
  selector: 'app-gender',
  templateUrl: './gender.component.html',
  styleUrls: ['./gender.component.css']
})
export class GenderComponent implements OnInit {

  formGroup;
  genders: Array<any> = []; 
  gender = {
    Name: String
  }

  constructor(
    private formBuilder: FormBuilder,
    private genderService: GenderService
  ) { 
    this.formGroup = this.formBuilder.group({
      Name: ''
    });
  }

  ngOnInit(): void {
    this.getGenders();
  }

  getGenders() {
    return this.genderService.getGenders().subscribe((res : any) => {
      
      this.genders = res.data;
    });
  }

  deleteGender(id: number){
    return this.genderService.deleteGender(id).subscribe((res : any) => {
      if(res.data){
        alert("eliminado exitosamente");
        this.getGenders();
      }else{
        alert("Error interno del servidor");
      }
      
      console.log(res);
      
    });
  }


  postGender(formData: any){ 

    let validate = this.validateField(formData);
    if(validate){
        this.genderService.postGender(formData).toPromise().then(data => {
          alert("Genero creado exitosamente");
          this.getGenders();
        })
    }
  }

  validateField(data: any){
    if(data.Name != ""){
      return true;
    }

    alert("Completa todo los campos");
    return false;
  }

}
