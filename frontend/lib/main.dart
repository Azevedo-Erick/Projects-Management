import 'dart:io';

import 'package:flutter/material.dart';
import 'package:frontend/pages/configurations/configurations_page.dart';
import 'package:get/get.dart';
import 'package:provider/provider.dart';

import 'stores/configurations_store.dart';
import 'shared/themes/themes.dart';
import 'utils/my_http_overrides.dart';

void main() {
  HttpOverrides.global = MyHttpOverrides();

  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // ignore: prefer_const_constructors_in_immutables
  MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
        create: (context) => ConfigurationsStore(),
        child: Consumer<ConfigurationsStore>(builder: (context, value, child) {
          return GetMaterialApp(
            debugShowCheckedModeBanner: false,
            title: 'Projects Management',
            themeMode: value.themeMode,
            theme: lightTheme,
            darkTheme: darkTheme,
            home: const ConfigurationsScreen(),
          );
        }));
  }
}
