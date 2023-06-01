import 'dart:convert';

class ProjectModel {
  final String name;
  final String release;

  ProjectModel({required this.name, required this.release});

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'name': name,
      'release': release,
    };
  }

  factory ProjectModel.fromMap(Map<String, dynamic> map) {
    return ProjectModel(
      name: map['Name'] as String,
      release: map['Release'] as String,
    );
  }

  String toJson() => json.encode(toMap());

  factory ProjectModel.fromJson(String source) =>
      ProjectModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
