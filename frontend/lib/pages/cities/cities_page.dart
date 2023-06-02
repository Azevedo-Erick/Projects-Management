import 'package:flutter/material.dart';
import 'package:get/get.dart';

import '../../controllers/cities_controller.dart';
import 'cities_binding.dart';

class CitiesPage extends StatefulWidget {
  const CitiesPage({super.key});

  @override
  State<CitiesPage> createState() => _CitiesPageState();
}

class _CitiesPageState extends State<CitiesPage> {
  late final CitiesController _citiesController;
  @override
  void initState() {
    super.initState();
    setupCities();

    _citiesController = Get.find<CitiesController>();
    _citiesController.getCities();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(),
    );
  }

  Widget getListView() {
    return ListView.separated(
        itemBuilder: (context, index) {
          return null;
        },
        separatorBuilder: (context, index) => const Divider(),
        itemCount: 0);
  }
}
