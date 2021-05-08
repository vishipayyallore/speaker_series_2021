import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {

  @Input()
  numberOfStars = 5;
  @Input()
  currentRating = 0;

  @Output()
  ratingClicked: EventEmitter<number> = new EventEmitter<number>();

  stars = [];
  fullBandWidth = 30 * this.numberOfStars;
  ratingBandWidth = this.fullBandWidth;

  constructor() { }

  ngOnInit(): void {
    this.stars = Array(this.numberOfStars).fill(0);
  }

  ngOnChanges(): void {
    this.ratingBandWidth = this.currentRating * (this.fullBandWidth / this.numberOfStars);
  }

  whenRatingClicked(): void {
    this.ratingClicked.emit(this.currentRating);
  }
}
