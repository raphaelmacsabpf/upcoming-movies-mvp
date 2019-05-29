import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { MatCardModule, MatButtonModule} from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UpcomingMoviesComponent} from './components/upcoming-movies/upcoming-movies.component';
import { UpcomingMoviesService } from './services/upcoming-movies.service';

@NgModule({
  declarations: [
    AppComponent,
    UpcomingMoviesComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule,
    MatCardModule,
    MatButtonModule
  ],
  providers: [UpcomingMoviesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
