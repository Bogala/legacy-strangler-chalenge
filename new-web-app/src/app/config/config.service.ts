import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Config } from './Config';
import { LegacyLinks } from './LegacyLinks';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  config: Observable<Config[]>;

  constructor(private httpClient: HttpClient) { }

  getLegacyLinks(id: number): LegacyLinks {
    return new LegacyLinks(id);
  }
}
