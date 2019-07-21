import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { TunerComponent } from './tuner/tuner.component';
import { TunerDetailComponent } from './tuner/details/details.component';
import { TunerEditComponent } from './tuner/edit/edit.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  {
    path: 'tuner', component: TunerComponent, children: [
      { path: ':id', component: TunerDetailComponent },
      { path: 'new', component: TunerEditComponent },
      { path: ':id/edit',  component: TunerEditComponent},
    ]
  }, 
]
@NgModule({
  imports: [RouterModule.forRoot(appRoutes)], 
  exports: [RouterModule]
})

export class AppRoutingModule { }
