import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AppRoutingModule } from './app-routing.module';
import { TunerComponent } from './tuner/tuner.component';
import { TunerEditComponent } from './tuner/edit/edit.component';
import { TunerDetailComponent } from './tuner/details/details.component';
import { TunerItemComponent } from './tuner/list/item/tuner-item.component'
import { TunerListComponent } from './tuner/list/list.component';
import { TunerService } from './tuner/tuner.service';
import { HeaderComponent } from './tuner/header/header.component';
import { WindRefService } from './wind-ref.service';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TunerComponent,
    TunerListComponent,
    TunerItemComponent,
    TunerEditComponent,
    TunerDetailComponent,
    HeaderComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,

  ],
  providers: [TunerService, WindRefService],
  bootstrap: [AppComponent]
})
export class AppModule { }
