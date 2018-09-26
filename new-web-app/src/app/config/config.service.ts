import { Injectable } from '@angular/core';
import { LegacyLinks } from './LegacyLinks';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor() { }

  getLegacyLinks(id: number): LegacyLinks {
    return new LegacyLinks(id);
  }
}
