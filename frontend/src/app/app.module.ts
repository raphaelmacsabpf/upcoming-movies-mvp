import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { MatCardModule, MatButtonModule, MatIconModule} from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UpcomingMoviesComponent} from './components/upcoming-movies/upcoming-movies.component';
import { UpcomingMoviesService } from './services/upcoming-movies.service';
import { UpcomingMovieDetailsComponent } from './components/upcoming-movie-details/upcoming-movie-details.component';

@NgModule({
  declarations: [
    AppComponent,
    UpcomingMoviesComponent,
    UpcomingMovieDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule
  ],
  providers: [UpcomingMoviesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
