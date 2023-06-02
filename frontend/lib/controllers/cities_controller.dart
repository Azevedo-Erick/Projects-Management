import 'package:get/get.dart';

import '../data/models/city_model.dart';
import '../data/repositories/city_repository.dart';

class CitiesController extends GetxController {
  final CityRepository cityRepository;
  final List<CityModel> _cities = <CityModel>[].obs;
  final RxBool _isLoading = false.obs;

  List<CityModel> get cities => _cities;
  RxBool get isLoading => _isLoading;

  CitiesController({required this.cityRepository});

  getCities() async {
    _isLoading.value = true;

    final response = await cityRepository.getAll();

    _cities.addAll(response);

    _isLoading.value = false;
  }
}
