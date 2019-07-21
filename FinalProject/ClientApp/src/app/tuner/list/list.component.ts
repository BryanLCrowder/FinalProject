import { Component, OnInit, OnDestroy } from '@angular/core';
import { Tuner } from '../tuner.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { TunerService } from '../tuner.service';


@Component({
  selector: 'tuner-list',
  templateUrl: './list.component.html'
})
export class TunerListComponent {
  tuner: Tuner[] = [];
  subscription: Subscription;

  constructor(private tunerService: TunerService,
    private router: Router,
    private route: ActivatedRoute) {
    this.tunerService.getTuners();
  }

  ngOnInit() {
    this.subscription = this.tunerService.tunerListChangedEvent
      .subscribe(
        (tunersList: Tuner[]) => {
          this.tuner = tunersList;
        }
      );
  }
  onNewTuner() {
    this.router.navigate(['new'], { relativeTo: this.route });
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
