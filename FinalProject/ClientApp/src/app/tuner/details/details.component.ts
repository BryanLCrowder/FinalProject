import { Component, OnInit } from '@angular/core';
import { Tuner } from '../tuner.model';
import { TunerService } from '../tuner.service';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { WindRefService } from '../../wind-ref.service';

@Component({
    selector: 'tuner-detail',
    templateUrl: './details.component.html'
})
export class TunerDetailComponent implements OnInit {
    tuner: Tuner;
    id: string;

    constructor(private tunerService: TunerService,
        private route: ActivatedRoute,
      private router: Router) {
      
    }

    ngOnInit() {
        this.route.params
            .subscribe(
                (params: Params) => {
                    this.id = params['id'];
                    this.tuner = this.tunerService.getTuner(this.id);
                }
            );
    }
  
    onDelete() {
        this.tunerService.deleteTuner(this.tuner);
        this.router.navigate(['/tuner']);
    }

}
