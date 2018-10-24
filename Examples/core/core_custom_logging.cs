using Raylib;
using static Raylib.Raylib;

public partial class Examples
{
    /*******************************************************************************************
    *
    *   raylib [core] example - Custom logging
    *
    *   This example has been created using raylib 2.1 (www.raylib.com)
    *   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
    *
    *   Copyright (c) 2018 Ramon Santamaria (@raysan5) and Pablo Marcos Oltra (@pamarcos)
    *
    ********************************************************************************************/



    // Custom logging funtion
    void LogCustom(int msgType, const char *text, va_list args)
    {
    	char timeStr[64];
    	time_t now = time(NULL);
    	struct tm *tm_info = localtime(&now);

    	strftime(timeStr, sizeof(timeStr), "%Y-%m-%d %H:%M:%S", tm_info);
    	printf("[%s] ", timeStr);

    	switch (msgType)
    	{
    		case LOG_INFO: printf("[INFO] : "); break;
    		case LOG_ERROR: printf("[ERROR]: "); break;
    		case LOG_WARNING: printf("[WARN] : "); break;
    		case LOG_DEBUG: printf("[DEBUG]: "); break;
    		default: break;
    	}

    	vprintf(text, args);
    	printf("\n");
    }

    public static int core_custom_logging()
    {
    	// Initialization
    	//--------------------------------------------------------------------------------------
    	int screenWidth = 800;
    	int screenHeight = 450;

    	// First thing we do is setting our custom logger to ensure everything raylib logs
    	// will use our own logger instead of its internal one
    	SetTraceLogCallback(LogCustom);

    	InitWindow(screenWidth, screenHeight, "raylib [core] example - custom logging");

    	SetTargetFPS(60);
    	//--------------------------------------------------------------------------------------

    	// Main game loop
    	while (!WindowShouldClose())    // Detect window close button or ESC key
    	{
    		// Update
    		//----------------------------------------------------------------------------------
    		// TODO: Update your variables here
    		//----------------------------------------------------------------------------------

    		// Draw
    		//----------------------------------------------------------------------------------
    		BeginDrawing();

    		ClearBackground(RAYWHITE);

    		DrawText("Check out the console output to see the custom logger in action!", 60, 200, 20, LIGHTGRAY);

    		EndDrawing();
    		//----------------------------------------------------------------------------------
    	}

    	// De-Initialization
    	//--------------------------------------------------------------------------------------
    	CloseWindow();        // Close window and OpenGL context
    	//--------------------------------------------------------------------------------------

    	return 0;
    }

}
