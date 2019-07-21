import { Injectable, EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Tuner } from './tuner.model';

@Injectable()
export class TunerService {
  tunerSelectedEvent = new EventEmitter<Tuner[]>();
  tunerListChangedEvent = new Subject<Tuner[]>();
  tuners: Tuner[] = [];
  maxTunerId: number;

  constructor(private http: HttpClient) {
    this.maxTunerId = this.getMaxId();
  }

  getTuners() {
    this.http.get('/api/Tuners')
      .subscribe(
        (res) => {
    
          this.tunerListChangedEvent.next(this.tuners);
        }, (error: any) => {
          console.log('something bad happened...');
        }
      );
  }

  getTuner(id: string): Tuner {
    for (const tuner of this.tuners) {
      if (tuner.id === id) {
        return tuner;
      }
    }
    return null;
  }

  getMaxId(): number {
    let maxId = 0;
    for (const tuner of this.tuners) {
      const currentId = parseInt(tuner.id, 10);
      if (currentId > maxId) {
        maxId = currentId;
      }
    }
    return maxId;
  }

  addTuner(newTuner: Tuner) {
    if (!newTuner) {
      return;
    }

    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    newTuner.id = '';
    const strTuner = JSON.stringify(newTuner);

    this.http.post<{ message: string, tuners: Tuner[] }>('/api/Tuners',
      strTuner,
      { headers: headers })
      .subscribe(
        (res) => {
          this.tuners = res.tuners;
          this.tuners.sort((a, b) => (a.model < b.model) ? 1 : (a.model > b.model) ? -1 : 0);
          this.tunerListChangedEvent.next(this.tuners.slice());
        });
  }

  updateTuner(originalTuner: Tuner, newTuner: Tuner) {
    if (!originalTuner || !newTuner) {
      return;
    }

    const pos = this.tuners.indexOf(originalTuner);
    if (pos < 0) {
      return;
    }

    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const strTuner = JSON.stringify(newTuner);

    this.http.patch<{ message: string, tuners: Tuner[] }>('/api/Tuners' + originalTuner.id
      , strTuner
      , { headers: headers })
      .subscribe(
        (responseData) => {
          this.tuners = responseData.tuners;
          this.tuners.sort((a, b) => (a.model < b.model) ? 1 : (a.model > b.model) ? -1 : 0);
          this.tunerListChangedEvent.next(this.tuners.slice());
        });
  }

  deleteTuner(tuner: Tuner) {
    if (tuner === null || tuner === undefined) {
      return;
    }

    this.http.delete<{ message: string, tuners: Tuner[] }>('/api/Tuners' + tuner.id)

      .subscribe(
        (responseData) => {
          this.tuners = responseData.tuners;
          this.tuners.sort((a, b) => (a.model < b.model) ? 1 : (a.model > b.model) ? -1 : 0);
          this.tunerListChangedEvent.next(this.tuners.slice());
        });
}
}

