import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UpcomingMoviesComponent } from './components/upcoming-movies/upcoming-movies.component';
import { UpcomingMovieDetailsComponent } from './components/upcoming-movie-details/upcoming-movie-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'upcoming-movies/1', pathMatch: 'full' },
  { path: 'upcoming-movies/:pageId', component: UpcomingMoviesComponent },
  { path: 'details/:id', component: UpcomingMovieDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
