import { Component } from '@angular/core';
import { Genre } from 'src/app/models/genre';
import { ActivatedRoute, Router } from '@angular/router';
import { Result } from 'src/app/models/result';
import { UpcomingMoviesService } from 'src/app/services/upcoming-movies.service';

@Component({
  selector: 'upcoming-movie-details',
  templateUrl: './upcoming-movie-details.component.html',
  styleUrls: ['./upcoming-movie-details.component.css'],
})

export class UpcomingMovieDetailsComponent {
  baseUrlToImages: string = "https://image.tmdb.org/t/p/w1280";
  upcomingMovie: Result;  

public constructor(
    private route: ActivatedRoute,
    private router: Router,
    private upcomingMoviesService: UpcomingMoviesService
) {
    this.upcomingMovie = upcomingMoviesService.selectedUpcomingMovie;
    if(this.upcomingMovie === undefined) {
      router.navigate(["/"]);
    }
  }

  public formatGenres(genres: Genre[]) {    
    return genres.map(genre => genre.name).join(", ");
  }
}
