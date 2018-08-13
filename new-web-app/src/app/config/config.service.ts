import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, find } from 'rxjs/operators';
import { Config } from './Config';
import { LegacyLinks } from './LegacyLinks';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  config: Observable<Config[]>;

  constructor(private httpClient: HttpClient) { }
  
  ensureConfig(): Observable<Config[]> {
    if (!this.config) {
      this.config = this.httpClient.get("http://localhost:50538/api/strangler/config").pipe(
        map((res: object) => Object.entries(res).map(([key, value]: any) => new Config(key, value)))
      );
    }

    return this.config;
  }

  getConfig(key: string): Observable<Config> {
    return this.ensureConfig().pipe(find((config: Config) => config[0].Key === key));
  }

  getLegacyLinks(id: number): Observable<LegacyLinks> {
    return this.getConfig("legacy::app").pipe(map((config: Config) => new LegacyLinks(config[0].Value, id)));
  }
}
