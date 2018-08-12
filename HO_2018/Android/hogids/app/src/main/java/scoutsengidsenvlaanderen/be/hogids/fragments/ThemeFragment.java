package scoutsengidsenvlaanderen.be.hogids.fragments;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import scoutsengidsenvlaanderen.be.hogids.LocalStorage;
import scoutsengidsenvlaanderen.be.hogids.R;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ThemeFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ThemeFragment extends Fragment {

    private TextView lblIntroTitle;
    private TextView lblIntroSubTitle;
    private TextView lblIntroText;

    public ThemeFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment.
     *
     * @return A new instance of fragment ThemeFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ThemeFragment newInstance() {
        ThemeFragment fragment = new ThemeFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_theme, container, false);
        lblIntroTitle = view.findViewById(R.id.lblIntroTitle);
        lblIntroSubTitle = view.findViewById(R.id.lblintroSubtitle);
        lblIntroText = view.findViewById(R.id.lblIntroText);


        lblIntroTitle.setText(LocalStorage.getInstance().getCopy("Song_Title"));
        lblIntroSubTitle.setText(LocalStorage.getInstance().getCopy("Song_Subtitle"));
        lblIntroText.setText(LocalStorage.getInstance().getCopy("Song_Text"));
        return view;
    }

}
