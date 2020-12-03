import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ActorComponent } from './Components/Actor/actor/actor.component';
import { CountryComponent } from './Components/country/country.component';
import { GenderComponent } from './Components/gender/gender.component';
import { MovieComponent } from './Components/movie/movie.component';

@NgModule({
  declarations: [
    AppComponent,
    ActorComponent,
    CountryComponent,
    GenderComponent,
    MovieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
