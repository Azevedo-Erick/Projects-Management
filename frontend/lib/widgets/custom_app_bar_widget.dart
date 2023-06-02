import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class CustomAppBarWidget extends StatelessWidget
    implements PreferredSizeWidget {
  final Widget body;
  final String name;
  const CustomAppBarWidget({super.key, required this.body, required this.name});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width,
      margin: const EdgeInsets.symmetric(horizontal: 11),
      decoration: const BoxDecoration(
          color: Color(0xff1F2937),
          borderRadius: BorderRadius.only(
            bottomLeft: Radius.circular(16),
            bottomRight: Radius.circular(16),
          )),
      padding: const EdgeInsets.only(bottom: 13, left: 13, right: 13, top: 21),
      child: Column(
        children: [
          Row(
            crossAxisAlignment: CrossAxisAlignment.center,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              GestureDetector(
                  onTap: () {
                    Scaffold.of(context).openDrawer();
                  },
                  child: const Icon(
                    Icons.menu_rounded,
                    color: Color(0xfff59e0b),
                    size: 58,
                  )),
              const Spacer(),
              Text(name,
                  style: GoogleFonts.montserrat(
                    fontSize: 32,
                  )),
              const Spacer(),
              const Spacer()
            ],
          ),
          body
        ],
      ),
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(kToolbarHeight + 240);
}
