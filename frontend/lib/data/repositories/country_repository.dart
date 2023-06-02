import 'dart:io';

import 'package:dio/dio.dart';

import '../models/country_model.dart';

class CountryRepository {
  final Dio dio;
  CountryRepository({required this.dio});

  Future<List<CountryModel>> getAll() async {
    final result = await dio.get('https://localhost:7289/v1/cities');
    final List<CountryModel> countries = [];
    sleep(const Duration(seconds: 5));
    if (result.statusCode == 200) {
      result.data["data"]
          .map((item) => countries.add(CountryModel.fromMap(item)))
          .toList();
    }
    return countries;
  }
}
