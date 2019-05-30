import { Component } from '@angular/core';
import { UpcomingMoviesService } from 'src/app/services/upcoming-movies.service';
import { UpcomingMovies } from 'src/app/models/upcoming-movies';
import { ActivatedRoute, Router } from "@angular/router";
import { Genre } from 'src/app/models/genre';
import { Result } from 'src/app/models/result';

@Component({
  selector: 'upcoming-movies',
  templateUrl: './upcoming-movies.component.html',
  styleUrls: ['./upcoming-movies.component.css'],
})

export class UpcomingMoviesComponent {
  upcomingMovies: UpcomingMovies;
  baseUrlToImages: string = "https://image.tmdb.org/t/p/w500";
  private routeSubscription: any;
  private upcomingMoviesServiceSubscription: any;
  private pageId: number;
  

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private upcomingMoviesService: UpcomingMoviesService
  ) 
  { }

  ngOnInit() {
    this.routeSubscription = this.route.params.subscribe(routeParameters => {
      if(routeParameters['pageId'] === undefined) {
        return;
      }

      this.pageId = +routeParameters['pageId'];
      this.upcomingMoviesServiceSubscription = this.upcomingMoviesService.getUpcomingMovies(this.pageId).subscribe(upcomingMovies => this.upcomingMovies = upcomingMovies);
    });
  }

  ngOnDestroy() {
    this.routeSubscription.unsubscribe();
    this.upcomingMoviesServiceSubscription.unsubscribe();
  }

  public joinGenres(genres: Genre[]) {    
    return genres.map(genre => genre.name).join(", ");
  }

  public goToDetails(upcomingMovie: Result) {
    this.upcomingMoviesService.selectedUpcomingMovie = upcomingMovie;
    this.router.navigate(['/details/', upcomingMovie.id]);
  }
}