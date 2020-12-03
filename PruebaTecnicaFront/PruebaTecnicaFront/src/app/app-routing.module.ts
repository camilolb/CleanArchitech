import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ActorComponent } from '../app/Components/Actor/actor/actor.component'
import {CountryComponent} from '../app/Components/country/country.component'
import {GenderComponent} from '../app/Components/gender/gender.component'
import {MovieComponent} from '../app/Components/movie/movie.component';

const routes: Routes = [
  {
    path : 'Movies',
    component: MovieComponent
  },
  {
    path : 'Actors',
    component: ActorComponent
  },
  {
    path : 'Country',
    component: CountryComponent
  },
  {
    path : 'Gender',
    component: GenderComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
