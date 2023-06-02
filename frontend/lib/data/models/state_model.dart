// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'country_model.dart';

class StateModel {
  final int id;
  final String name;
  final CountryModel? country;

  StateModel({
    required this.id,
    required this.name,
    this.country,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'name': name,
      'country': country?.toMap(),
    };
  }

  factory StateModel.fromMap(Map<String, dynamic> map) {
    return StateModel(
      id: map['id'] as int,
      name: map['name'] as String,
      country: map['country'] != null
          ? CountryModel.fromMap(map['country'] as Map<String, dynamic>)
          : null,
    );
  }

  String toJson() => json.encode(toMap());

  factory StateModel.fromJson(String source) =>
      StateModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
