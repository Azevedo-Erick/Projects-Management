import 'package:flutter/material.dart';

part 'color_schemes.g.dart';

ThemeData get lightTheme => ThemeData(
    useMaterial3: true,
    colorScheme: lightColorScheme,
    appBarTheme: AppBarTheme(
        titleTextStyle:
            TextStyle(color: lightColorScheme.onPrimary, fontSize: 18),
        backgroundColor: lightColorScheme.primary),
    radioTheme: RadioThemeData(
        fillColor: MaterialStateProperty.all(
      lightColorScheme.primary,
    )));

ThemeData get darkTheme => ThemeData(
    useMaterial3: true,
    colorScheme: darkColorScheme,
    appBarTheme: AppBarTheme(
        titleTextStyle:
            TextStyle(color: darkColorScheme.onPrimary, fontSize: 18),
        backgroundColor: darkColorScheme.primary),
    radioTheme: RadioThemeData(
        fillColor: MaterialStateProperty.all(
      darkColorScheme.primary,
    )));
