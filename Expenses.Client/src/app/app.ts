import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from './header/header';
import { TransactionList } from './transaction-list/transaction-list';
import { Footer } from './footer/footer';

@Component({
  imports: [RouterOutlet, Header, TransactionList, Footer],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('Expenses.Client');
}
