import { Component, OnInit, Input } from '@angular/core';
import { User } from '../../user';
import { LegacyLinks, ConfigService } from 'src/app/config';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.css']
})
export class UserItemComponent implements OnInit {
  @Input()  user: User;
  legacyLinks: LegacyLinks;

  constructor(private configService: ConfigService) { }

  ngOnInit() {
    this.legacyLinks = this.configService.getLegacyLinks(this.user.Id);
  }
}
