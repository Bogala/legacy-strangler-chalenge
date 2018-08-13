import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { UserModule } from './user/user.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './app/header/header.component';
import { FooterComponent } from './app/footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    UserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
