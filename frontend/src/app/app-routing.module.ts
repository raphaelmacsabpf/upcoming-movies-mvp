import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UpcomingMoviesComponent } from './components/upcoming-movies/upcoming-movies.component';

const routes: Routes = [
  { path: '', redirectTo: 'upcoming-movies/1', pathMatch: 'full' },
  { path: 'upcoming-movies/:pageId', component: UpcomingMoviesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
