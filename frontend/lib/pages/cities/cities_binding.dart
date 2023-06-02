import 'package:dio/dio.dart';
import 'package:get/get.dart';

import '../../controllers/cities_controller.dart';
import '../../data/repositories/city_repository.dart';

setupCities() {
  Get.put<CitiesController>(
      CitiesController(cityRepository: CityRepository(dio: Dio())));
}
